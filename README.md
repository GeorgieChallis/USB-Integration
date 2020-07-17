# BI3UI16: USB Integration Module Coursework

A simple ‘musical instrument’ style peripheral was created by building on reference software for the Explorer 16 development board. Device firmware and a Windows PC application were modified to communicate button presses and potentiometer states using commands over USB. The human inputs trigger sounds and visuals for
music making. This basic prototype could easily be built upon further in many audio-based applications and improved to decrease input lag.

## 1. Introduction
The aim of this project was to create a new "product" based on the Human Interface Device (HID) demo code available for the Explorer 16 development board. 

Inspired by the “reach out and touch” audio devices in Nicolas Collins’ 2006 book ‘Homemade Electronic Music: The Art of Hardware Hacking’[1][1], the on-board buttons and potentiometer were used to create a USB controller that can be used to generate different sounds in a PC application.

Reference software from Microchip was used to implement a 2-way interface between the peripheral and a host PC, using sample code device firmware and a basic host application as a framework was built upon to create a new solution.

## 2. Specifications
## 2.1. System Description
The product is be a hardware interface and supporting application to take user inputs and give varied audible and visual outputs. Development of the system will consist of 3 main parts: setting up the hardware, developing the HID firmware, and building up the application for the host PC.

The hardware set-up will follow the recommended configuration for the Microchip Explorer 16 development board, as found on the product website [2][2]. The HID device will make use of the development board components to receive inputs from the user in real-time. These interactions will need to be communicated over USB to a host computer, which will display a graphical user interface (GUI) for the user to see and hear the results of their input. By pressing different buttons and turning the potentiometer to different positions, music can be played by combining the different audio outputs.

## 2.2. Requirements

In order to operate as a simple input device for audio, the peripheral and application must:
1. Communicate by sending messages over USB
2. React to button presses with visual indicators and audio outputs
3. React to the potentiometer being moved by changing between different audio ‘modes’
4. Provide simple instructions to the user on the peripheral itself
5. Not fail when presented with multiple simultaneous button presses
6. Not crash when the peripheral is disconnected

Reasonable response speeds should be considered when testing the product to avoid a jarring user experience, but speeds matching real devices on the market are not expected for an initial attempt.

# 3. Existing Functionality
The Explorer board includes a number of different user interaction components. These include 4 push buttons and a potentiometer for user inputs and an LCD screen and LEDs for visual output [2][2]. The configuration used for this project includes a PIC32 Plug-In Module (PIM) which can be programmed with firmware to handle interaction and processing, and a PICtail Plus expansion board to communicate with a host computer via USB cable, as seen in Figure 1 below.






Figure 1. Hardware Configuration for Explorer 16 Board

To speed up the development time, demo software available from Microchip was used as a framework to build upon. This includes a sample Windows Forms application, written in C#, which displays the state of a single push-button, the value from a potentiometer position as a percentage bar and a status box that explains the current communication state. There is also a button to click to toggle the LEDs. The provided firmware for the peripheral device handles some of the inputs with a set of command codes to send and receive data across the USB control endpoint 0, enabling communication with the application [3][3].

# 4. Peripheral Firmware
## 4.1 Command Codes
Communication between the host and the device is simplified by taking advantage of the existing command codes in firmware. When an application needs the device to perform a certain operation, a hexadecimal code is sent over USB endpoint 0 to indicate which function is required. The HID regularly checks whether or not data was received from the host application, comparing the first element in the data buffer against defined command codes. If this matches a number in the switch statement, the corresponding block of code is executed. For example, if the device sees 0x80 in ReceivedDataBuffer[0], the function to toggle the LEDs is performed. This project uses 0x81 to get the push-button states and 0x37 for reading the potentiometer.

## 4.1. Button Presses
The first part of this project was to detect button presses on all 4 of the Explorer board’s push buttons. Each button was defined with its corresponding pins in the hardware profile header file `HardwareProfile - PIC32MX460F512L PIM.h` and set as switches 1 – 4 with pins RD6, RD7, RA7 and RD13 respectively. For example, switch 1 on the board is initialised at the start of the code with _mInitSwitch1()_ where the digital bit D6 is set with _TRISDbits.TRISD6=1_.

The code evaluates whether each switch has been pressed by checking the state of the defined pins (eg. sw1 checks the state of PORTDbits.RD6). If the button is not pressed, the pull-up resistor on the board forces the PORT pin high (1). Once the button is pressed the pin goes low (0). 

Once the pins were defined, all 4 buttons were added to command code 0x81, which originally returned a single button state. When command 0x81 is called, the first element of the data buffer is populated with the command code again to confirm the type of data being sent. The following 4 bytes of data contain the states of each button where 0x00 means the button is pressed down.

## 4.2. Potentiometer
When command 0x37 is called, the ReadPOT() method is called. The voltage at the potentiometer is measured and converted to a digital value with the Analogue to Digital Converter (ADC). As the pot is turned, the ADC values change to represent this with a value from 0 to 1024. Similar to the button command, the buffer is populated with the original hexadecimal command in byte 0 and then the following 2 bytes hold the most significant and least significant bytes for the 16-bit ADC value.

## 4.3. LCD Screen
The board’s LCD screen was configured to meet the specification for providing simple user instructions. Pre-existing header files for configuring the LCD were imported into the project to set up the pins and functions for use. This made it simple to implement the LCDDisplayString() function and pass in strings of up to 16 characters for each of the two lines on the screen. This was used at the start of the while loop encompassing the main firmware code, so was initialised once on set-up and not modified throughout the use of the application.

# 5. Host Application
The HID demo code provides a rudimentary Graphical User Interface (GUI) created with Windows Forms to display the states of a single button, LED and potentiometer. This base C# code was used as a framework for the musical instrument application by leveraging other available .NET methods and writing a new Scales class for playing audio. A new GUI was built up with WinForms elements from the Visual Studio toolbox.

## 5.1. Requesting Peripheral States
In the ReadWrite thread of the application, packets containing the command codes are sent to the USB device with the WriteFile() function via the OUTBuffer. The first byte is the ReportID which is always 0 and is not sent over the USB bus. Following this is the command to return the ADC value or the push-button states. The remaining bytes of the packet are set to 1s to reduce power and stop toggling states on the line as per Non-Return to Zero Inverted (NRZI) encoding [7][7].

The results from the commands are then read from the INBuffer. The 2 bytes forming the ADC value are converted to the unsigned integer ‘ADCValue’ and the push button states are used to set Boolean states for ‘PushButtonPressed’ (a value of 0x00 sets PushButtonPressed to True 0x01 to False, because of the action of the pull-up resistor on the board). These variables are made global so they can be accessed throughout the application.

## 5.2. Playing Sounds
The audio outputs were created with 2 different methods. For the electronic ‘piano’ notes, the .NET Console method Console.Beep() was used. This takes two integers for the sound frequency and the duration in milliseconds and plays it through the PC’s soundcard when called [4][4]. For drum sounds, 4 audio files were downloaded, cut down with the Audacity editor and embedded into the executable.

When the drums were selected, each button corresponded to a sound file, playing using the SoundPlayer class in System.Media synchronously when the button is pressed [5][5].

It is possible to implement more complex libraries such as the NAudio toolkit for .NET to provide a wider range of realistic instrument sounds [6][6] but, with the limited number of buttons and potentiometer range, the project would not be able to take advantage of these extra options. This would also consume more memory for the program and increase the development time.

## 5.3. Notes and Scales Classes
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

Values 0 – 409 contain the C Major scale between the first 2 modes to include all the white notes of a piano. To give some range, mode 3 increased the notes by an octave, doubling the frequencies. To keep this scale to 4 buttons, the pentatonic (5 note) scale was selected and the first C was removed Mode 4 used the first part of the B♭ Minor scale to include some of the black piano notes, whilst not sounding dissonant when played together. The drum mode was selected when the ADC value was between 820 and 1024. This changes to use to Snap, Kick, Tom and Snare audio files for buttons 1 – 4 so does not make use of the Scales class.

## 5.4. Form Elements
The piano layout was created using 12 rectangular buttons from the WinForm toolbox, as shown in Figure 2(a) below. Each software button is linked to its corresponding note and, in addition to playing the relevant sound, changes the note’s background colour when played with the physical push button.


(a) (b)
Figure 2. Final host application layout; (a) Piano keys layout; (b) Drum mode layout.

Note colours are handled with an if statement in the Form.cs code which checks whether the frequency is divisible by the note’s first octave’s frequency – a change of one octave equates to doubling the frequency. For example, if a note at 262Hz, 524Hz or 1,048kHz is played, the C piano key button will turn blue.

The label in the bottom right of the window shows the frequencies of notes in the selected mode and changes dynamically when the ADC value changes. For an ADC value greater than 820, the piano buttons become invisible and the drum image is displayed instead, as in Figure 2(b).

The status bar at the top of the window has been borrowed from the original demo GUI and shows the connectivity state of the Explorer board. If the device is plugged in and operating correctly, the bar should read “Device Found: AttachedState = TRUE”. If the board cannot be found or is failing to communicate, this will read “Device Not Detected: Verify Connection/Correct Firmware”.

# References
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

[9] Ableton (2018). Push: Music at your Fingertips [Online] Available:
https://www.ableton.com/en/push/

[10] MI.MU Gloves Ltd. (2018). MI.MU: Tech [Online] Available:
https://mimugloves.com/tech/

[11] J. Hass, Indiana University (2017) How does the MIDI system work? [Online] Available:
http://www.indiana.edu/~emusic/etext/MIDI/chapter3_MIDI13.shtml

All web addresses referred to here were last verified on 30th January 2019.
