using System;
using SheetMusic;
using MusicTheory.Rhythms;
using Batterie;

public class NewBatterie_State : State
{
    public NewBatterie_State()
    {
    }



    protected override void PrepareState(Action callback)
    {

        base.PrepareState(callback);
    }

    protected override void EngageState()
    {
        var RhythmSpecs = new RhythmSpecs()
        {
            Time = new FourFour(),
            NumberOfMeasures = 4,
            SubDivisionTier = SubDivisionTier.D1Only,
            HasTies = true,
            HasRests = false,
            HasTriplets = false,
            Tempo = 90
        };
        SetStateDirectly(new Batterie_State(RhythmSpecs));
    }


}
