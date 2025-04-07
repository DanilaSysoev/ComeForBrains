using ComeForBrains.Core.Characters;

namespace ComeForBrainsTests.Core.Characters;

[TestFixture]
public class PersonAttributeTests : Tests
{
    [Test]
    public void Create_WithoutPenalties_ReturnZeroValue()
    {
        var attr = new PersonAttribute(0, 10, new List<AttributePenalty>());
        for (var i = 0; i < 10; i++)
        {
            attr.Value = i;
            Assert.That(attr.GetPenalty(), Is.EqualTo(0));
        }
    }
    [Test]
    public void Create_WithOnePenalty_ReturnCorrectValueInPenaltyRange()
    {
        var attr = new PersonAttribute(
            0, 10, new List<AttributePenalty>
            {
                new AttributePenalty(0, 4, 10)
            }
        );
        for (var i = 0; i < 4; i++)
        {
            attr.Value = i;
            Assert.That(attr.GetPenalty(), Is.EqualTo(10));
        }
    }
    [Test]
    public void Create_WithOnePenalty_ReturnZeroOutOfPenaltyRange()
    {
        var attr = new PersonAttribute(
            0, 10, new List<AttributePenalty>
            {
                new AttributePenalty(0, 4, 10)
            }
        );
        for (var i = 4; i <= 10; i++)
        {
            attr.Value = i;
            Assert.That(attr.GetPenalty(), Is.EqualTo(0));
        }
    }
    [Test]
    public void Create_WithTwoPenalty_ReturnCorrectValueInPenaltiesRanges()
    {
        var attr = new PersonAttribute(
            0, 10, new List<AttributePenalty>
            {
                new AttributePenalty(0, 3, 10),
                new AttributePenalty(3, 6, 20)
            }
        );
        for (var i = 0; i < 3; i++)
        {
            attr.Value = i;
            Assert.That(attr.GetPenalty(), Is.EqualTo(10));
        }
        for (var i = 3; i < 6; i++)
        {
            attr.Value = i;
            Assert.That(attr.GetPenalty(), Is.EqualTo(20));
        }
    }
    [Test]
    public void Create_WithTwoPenalty_ReturnZeroOutOfPenaltiesRanges()
    {
        var attr = new PersonAttribute(
            0, 10, new List<AttributePenalty>
            {
                new AttributePenalty(0, 3, 10),
                new AttributePenalty(5, 8, 20)
            }
        );
        for (var i = 3; i < 5; i++)
        {
            attr.Value = i;
            Assert.That(attr.GetPenalty(), Is.EqualTo(0));
        }
        for (var i = 8; i <= 10 ; i++)
        {
            attr.Value = i;
            Assert.That(attr.GetPenalty(), Is.EqualTo(0));
        }
    }
    
    [Test]
    public void Value_SetLessThanMin_EqualsMin()
    {
        var attr = new PersonAttribute(0, 10, new List<AttributePenalty>());
        attr.Value = -1;
        Assert.That(attr.Value, Is.EqualTo(0));
    }
    [Test]
    public void Value_SetGreaterThanMax_EqualsMax()
    {
        var attr = new PersonAttribute(0, 10, new List<AttributePenalty>());
        attr.Value = 11;
        Assert.That(attr.Value, Is.EqualTo(10));
    }
}
