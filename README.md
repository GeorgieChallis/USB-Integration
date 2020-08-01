# BI3UI16: USB Integration Module Coursework

A simple ‘musical instrument’ was created by building on reference software for the Explorer 16 development board. Device firmware and a Windows PC application were modified to communicate button presses and potentiometer states using commands over USB. The human inputs trigger sounds and visuals for
music making. This basic prototype could easily be built upon further in many audio-based applications and improved to decrease input lag.

## 1. Introduction
**Brief:** Create a new product based on the Human Interface Device (HID) demo code available for the Explorer 16 development board. 

## 2. System Description
Inspired by the “reach out and touch” audio devices in Nicolas Collins’ 2006 book ‘Homemade Electronic Music: The Art of Hardware Hacking’[1], the on-board buttons and potentiometer were used to create a USB controller that can be used in a custom app to take user inputs and give varied audible and visual outputs. Development of the system consisted of 3 main parts: setting up the hardware, developing the HID firmware, and building up the application for the host PC.

The hardware set-up will follow the recommended configuration for the Microchip Explorer 16 development board, as found on the product website [2]. The HID device will make use of the development board components to receive inputs from the user in real-time.

<img src="https://github.com/GeorgieChallis/USB-Integration/blob/master/references/hardware-config.png" width="420">

## 3. Custom Graphical User Interface (GUI)
The HID demo displayd the state of a single button, LED and potentiometer. This was used as a framework for the musical instrument application with other .NET methods and writing a new `Scales.cs` class for playing audio. A new GUI was built up with WinForms elements from the Visual Studio toolbox.

<img src="https://github.com/GeorgieChallis/USB-Integration/blob/master/references/gui.png" width="560">

### 3.1. Requesting Peripheral States
In the ReadWrite thread of the application, packets containing the command codes are sent to the USB device with the WriteFile() function via the OUTBuffer. The first byte is the ReportID which is always 0 and is not sent over the USB bus. Following this is the command to return the ADC value or the push-button states. The remaining bytes of the packet are set to 1s to reduce power and stop toggling states on the line as per Non-Return to Zero Inverted (NRZI) encoding [7].

The results from the commands are then read from the INBuffer. The 2 bytes forming the ADC value are converted to the unsigned integer ‘ADCValue’ and the push button states are used to set Boolean states for ‘PushButtonPressed’ (a value of 0x00 sets PushButtonPressed to True 0x01 to False, because of the action of the pull-up resistor on the board). These variables are made global so they can be accessed throughout the application.

### 3.2. Playing Sounds
The audio outputs were created with 2 different methods. For the electronic ‘piano’ notes, the .NET Console method Console.Beep() was used. This takes two integers for the sound frequency and the duration in milliseconds and plays it through the PC’s soundcard when called [4]. For drum sounds, 4 audio files were downloaded, cut down with the Audacity editor and embedded into the executable.

When the drums were selected, each button corresponded to a sound file, playing using the SoundPlayer class in System.Media synchronously when the button is pressed [5].

### 3.3. Notes and Scales Classes
With the development board having only 4 push buttons, it did not seem sufficient for the user to only be able to play 4 different notes in total. To resolve this, the potentiometer was used to switch between sets of notes in different ‘scales’. The total range of the ADC was divided into 5 to give 5 distinct modes that the user could select by turning the pot (see Table 1 below).

Table 1: List of scales implemented in Scales.cs
| Scale Name                 | ADC Value | Note 1   | Note 2   | Note 3  | Note 4    |
| -------------------------- | --------- | -------- | -------- | ------- | --------- |
| C Major (Part 1)           | 0 – 204   | C1       | D1       | E1      | F1        |
| C Major (Part 2)           | 205 – 409 | G1       | A1       | B1      | C2        |
| C Maj (Pentatonic - tonic) | 410 - 614 | D2       | E2       | G2      | A2        |
| B♭ Minor (Part 1)          | 615 - 819 | A#     * | C1       | C#      | D#        |
| Drum Mode                  | 820 - 1024| Snap.wav | Kick.wav | Tom.wav | Snare.wav |

/* Common Digital Audio Workstations (DAW), give notes with “sharps” names rather than “flats”, i.e. A# = B♭

### 3.4. Form Elements
For the piano layout, each software button is linked to its corresponding note and, in addition to playing the relevant sound, changes the note’s background colour when played with the physical button. The note colours are handled with an if statement in the Form.cs code which checks whether the frequency is divisible by the note’s first octave’s frequency – a change of one octave equates to doubling the frequency. For example, if a note at 262Hz, 524Hz or 1,048kHz is played, the C piano key button will turn blue.

The label in the bottom right of the window shows the frequencies of notes in the selected mode and changes dynamically when the ADC value changes. For an ADC value greater than 820, the piano buttons become invisible and the drum image is displayed instead.

The status bar at the top of the window shows the connectivity state of the Explorer board. If the device is plugged in and operating correctly, the bar should read “Device Found: AttachedState = TRUE”. If the board cannot be found or is failing to communicate, this will read “Device Not Detected: Verify Connection/Correct Firmware”.

## 4. Peripheral Firmware
### 4.1 Command Codes
Communication is simplified by the existing command codes in firmware. When an application needs the device to perform a certain operation, a hexadecimal code is sent over USB endpoint 0 to indicate which function is required. The HID regularly checks whether or not data was received from the host application, comparing the first element in the data buffer against defined command codes. If this matches a number in the switch statement, the corresponding block of code is executed.

### 4.2. Button Presses
Each button was defined with its corresponding pins in the hardware profile header file `HardwareProfile - PIC32MX460F512L PIM.h` and set as switches 1 – 4 with pins RD6, RD7, RA7 and RD13 respectively. The code evaluates whether each switch has been pressed by checking the state of the defined pins (eg. sw1 checks the state of PORTDbits.RD6). If the button is not pressed, the pull-up resistor on the board forces the PORT pin high (1). Once the button is pressed the pin goes low (0). 
All 4 buttons were then added to command code 0x81. When called, the first element of the data buffer is populated with the command code again to confirm the type of data being sent. The following 4 bytes of data contain the states of each button (0x00 means the button is pressed).

### 4.3. Potentiometer
When command 0x37 is called, ReadPOT() is called. The voltage at the potentiometer is measured and converted to a digital value with the Analogue to Digital Converter (ADC). As the pot is turned, the ADC values change to represent this with a value from 0 to 1024.

### 4.4. LCD Screen
The board’s LCD screen was configured to meet the specification for providing simple user instructions. Pre-existing header files for configuring the LCD were imported into the project to set up the pins and functions for use.


## References
[1] N. Collins, Homemade Electronic Music: The Art of Hardware Hacking, 2nd ed. New York:
Routledge, 2006.

[2] Microchip (2014). Explorer 16 Development Board User’s Guide [Online] Available:
http://ww1.microchip.com/downloads/en/devicedoc/50001589b.pdf

[3] Microchip (2018). USB Endpoints [Online] Available:
http://microchipdeveloper.com/usb:endpoints

[4] Microsoft. .NET API Browser | Console.Beep Method [Online] Available:
https://docs.microsoft.com/en-us/dotnet/api/system.console.beep?view=netframework-4.7.2

[5] Microsoft. .NET API Browser | SoundPlayer Class [Online] Available:
https://docs.microsoft.com/en-us/dotnet/api/system.media.soundplayer?view=netframework4.7.2

[6] M. Heath (2008, Jun) Introducing NAudio - .NET Audio Toolkit [Online] Available:
https://markheath.net/post/introducing-naudio-net-audio-toolkit

[7] J. Slobodov Universal Serial Bus (USB) [Online] Available:
http://www.ece.ualberta.ca/~elliott/ee552/studentAppNotes/2001f/interfacing/usb/appl_note.
html

[8] B. G. Schultz (2018). The Schultz MIDI Benchmarking Toolbox for MIDI interfaces,
percussion pads and sound cards [Online] Available:
https://link.springer.com/content/pdf/10.3758%2Fs13428-018-1042-7.pdf

_All web addresses referred to here were last verified on 30th January 2019._
