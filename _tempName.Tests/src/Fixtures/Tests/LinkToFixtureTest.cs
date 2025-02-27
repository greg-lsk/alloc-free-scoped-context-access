namespace _tempName.Tests.Fixtures.Tests;

public class LinkToFixtureTest
{
    [Fact]
    public void ArrangeLinkTo_Returns_CorrectLink_WhenPrompted_ToReturnAnActiveOne()
    {
        // Arrange
        var fixture = new LinkToFixture();

        // Act
        var linkFromProvidedTarget = fixture.ArrangeLinkTo(LinkState.Active, 1);
        var actualTarget = linkFromProvidedTarget.Target;

        // Assert
        Assert.Equal(actual: actualTarget, expected: 1);
    }    

    [Fact]
    public void ArrangeLinkTo_Returns_ActiveLink_WhenPrompted_RegardlessOf_HavingTargetProvided()
    {
        // Arrange
        var fixture = new LinkToFixture();

        // Act
        var linkFromProvidedTarget = fixture.ArrangeLinkTo(LinkState.Active, 1);
        var linkFromNonProvidedTarget = fixture.ArrangeLinkTo<int>(LinkState.Active);

        // Assert
        Assert.True(linkFromProvidedTarget.IsActive());
        Assert.True(linkFromNonProvidedTarget.IsActive());
    }

    [Fact]
    public void ArrangeLinkTo_Returns_InactiveLink_WhenPrompted_RegardlessOf_HavingTargetProvided()
    {
        // Arrange
        var fixture = new LinkToFixture();

        // Act
        var linkFromProvidedTarget = fixture.ArrangeLinkTo(LinkState.Inactive, 1);
        var linkFromNonProvidedTarget = fixture.ArrangeLinkTo<int>(LinkState.Inactive);

        // Assert
        Assert.False(linkFromProvidedTarget.IsActive());
        Assert.False(linkFromNonProvidedTarget.IsActive());
    }

    [Fact]
    public void ArrangeLinkTo_Throws_InvalidDataException_WhenProvidingInvalidState()
    {
        // Arrange
        var fixture = new LinkToFixture();

        // Act
        void act() => fixture.ArrangeLinkTo((LinkState)8, 2);

        // Assert
        Assert.Throws<InvalidDataException>(act);
    }         
}