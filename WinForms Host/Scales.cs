using System;

public enum Tone
{
    REST = 0,
    C1 = 262,   D1 = 294,   E1 = 330,   G1 = 392,   A1 = 480,
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

    public Note(int frequency, int time) {
        int tone = frequency;
        int duration = time;
    }
}

public class MusicScale {
    public static Note[] Notes;
    public MusicScale(int potVal)
    {
        Notes = new Note[]{
            new Note((int) Tone.C1, (int) Duration.QUARTER),
            new Note((int) Tone.D1, (int) Duration.QUARTER),
            new Note((int) Tone.E1, (int) Duration.QUARTER),
            new Note((int) Tone.G1, (int) Duration.QUARTER),
            new Note((int) Tone.A1, (int) Duration.QUARTER)
        };
    }
}


