
using ComeForBrains.Core.Characters;

namespace ComeForBrainsSadConsoleUi.Screens.Components;

public class PersonInfoPanel : BorderedPanel
{
    public PersonInfoPanel(int width, int height) : base(width, height)
    {
        Fill();
    }

    public PersonInfoPanel(
        int width,
        int height,
        Color foregroung,
        Color background
    ) : base(width, height, foregroung, background)
    {
        Fill();
    }

    public void Fill()
    {
        person = Environment.Instance.Context.Person;

        FillName();

        FillAttribute((1, 3), L["SatietyName"], person.Satiety);
        FillAttribute((1, 4), L["EnergyName"], person.Energy);
        FillAttribute((1, 5), L["HealthName"], person.Health);
        FillAttribute((1, 6), L["ThirstName"], person.Thirst);

        FillStats(
            (1, 8),
            L["StrengthName"],
            person.Strength,
            person.StrengthModifier
        );
        FillStats(
            (1, 9),
            L["DexterityName"],
            person.Dexterity,
            person.DexterityModifier
        );
        FillStats(
            (1, 10),
            L["PhysiqueName"],
            person.Physique,
            person.PhysiqueModifier
        );
        FillStats(
            (1, 11),
            L["DistanceAccuracyName"],
            person.DistanceAccuracy,
            person.DistanceAccuracyModifier
        );
        FillStats(
            (1, 12),
            L["MeleeFightName"],
            person.MeleeFight,
            person.MeleeFightModifier
        );

        FillSpeed();
        FillMaxWeight();
    }

    private void FillMaxWeight()
    {
        Surface.Print(
            1, 16,
            $"{L["MaxWeight"]}: {person.MaxWeight:0.##} {L["kg"]}"
        );
    }

    private void FillSpeed()
    {
        Surface.Print(1, 14, $"{L["Speed"]}: {person.Speed:0.##}");
    }

    private void FillName()
    {
        Surface.Print(1, 1, person.Name);
    }

    private void FillAttribute(
        Point location,
        string name,
        PersonAttribute value
    )
    {
        Color color = CalculateColor(value);

        Surface.Print(
            location.X,
            location.Y,
            $"{name}: {value.Value:N1}/{value.MaxValue:N0}",
            color
        );
    }

    private static Color CalculateColor(PersonAttribute value)
    {
        var penalties =
                    value.Penalties
                         .OrderBy(penalty => penalty.FromInclusive)
                         .ToList();
        int penaltyIndex = FindPenaltyIndex(value, penalties);
        Color color =
            new Color(
                (penalties.Count - penaltyIndex) * 255 / penalties.Count,
                penaltyIndex * 255 / penalties.Count,
                0
            );
        return color;
    }

    private static int FindPenaltyIndex(
        PersonAttribute value, List<AttributePenalty> penalties
    )
    {
        var penaltyIndex = penalties.Count;
        for (int i = 0; i < penalties.Count; ++i)
        {
            if (value.Value >= penalties[i].FromInclusive &&
               value.Value < penalties[i].ToExclusive)
            {
                penaltyIndex = i;
                break;
            }
        }

        return penaltyIndex;
    }

    private void FillStats(
        Point location,
        string name,
        double value,
        double modifier
    )
    {
        Surface.Print(
            location.X,
            location.Y,
            $"{name}: {value:N1} ({modifier:N1})"
        );
    }

    private Person person = null!;
}
