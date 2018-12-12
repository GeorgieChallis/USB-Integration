using System;

public enum Tone
{
    REST = 0,
    C1 = 262,   D1 = 294,   E1 = 330,   F1 = 349, G1 = 392,   A1 = 440, B1 = 247*2,
    C2 = C1*2,  D2 = D1*2,  E2 = E1*2,  G2 = G1*2,  A2 = A1*2,
    C3 = C1*4,  D3 = D1*4,  E3 = E1*4,  G3 = G1*4,  A3 = A1*4,
    C4 = C1*8
}

public enum Duration
{
    WHOLE = 1600,
    HALF = WHOLE / 2,
    QUARTER = HALF / 2,
    EIGHTH = QUARTER / 2,
    SIXTEENTH = EIGHTH / 2,
}

public class Note {

    public int tone;
    public int duration;

    public Note(int frequency, int time) {
        tone = frequency;
        duration = time;
    }
}

public class MusicScale {
    public Note[] Notes;
    public MusicScale(int potVal)
    {
        if (potVal < 205)
        {
            Notes = new Note[]{
            new Note((int) Tone.C1, (int) Duration.QUARTER),
            new Note((int) Tone.D1, (int) Duration.QUARTER),
            new Note((int) Tone.E1, (int) Duration.QUARTER),
            new Note((int) Tone.F1, (int) Duration.QUARTER),
            };
        }
        else if (potVal < 410)
        {
            Notes = new Note[]{
            new Note((int) Tone.G1, (int) Duration.QUARTER),
            new Note((int) Tone.A1, (int) Duration.QUARTER),
            new Note((int) Tone.B1, (int) Duration.QUARTER),
            new Note((int) Tone.C2, (int) Duration.QUARTER),
            };
        }
        else if (potVal < 615)
        {
            Notes = new Note[]{
            new Note((int) Tone.G2, (int) Duration.QUARTER),
            new Note((int) Tone.A2, (int) Duration.QUARTER),
            new Note((int) Tone.C3, (int) Duration.QUARTER),
            new Note((int) Tone.D3, (int) Duration.QUARTER),
            };
        }
        else if (potVal < 820)
        {
            Notes = new Note[]{
            new Note((int) Tone.E3, (int) Duration.QUARTER),
            new Note((int) Tone.G3, (int) Duration.QUARTER),
            new Note((int) Tone.A3, (int) Duration.QUARTER),
            new Note((int) Tone.C4, (int) Duration.QUARTER),
            };
        }

        else {
            Notes = new Note[]{
            new Note((int) Tone.C1, (int) Duration.QUARTER),
            new Note((int) Tone.D1, (int) Duration.QUARTER),
            new Note((int) Tone.E1, (int) Duration.QUARTER),
            new Note((int) Tone.F1, (int) Duration.QUARTER),
            };
        }

        
    }
}


