using NUnit.Framework;
using RuleEngineSpikes.Engines.One;

namespace RuleEngineSpikes.Tests
{
    [TestFixture]
    public class EngineOneTest
    {
        [Test]
        public void DoStuff()
        {
            var ruleLoader = new RuleLoader();

            var firstRule = ruleLoader.Load(1);
            var secondRule = ruleLoader.Load(2);
            var thirdRule = ruleLoader.Load(3);

            var person = new Person() { Name = "Mathias", Age = 35, Children = 2 };

            var ruleEngine = new RuleEngine();

            var firstRuleFunc = ruleEngine.CompileRule<Person>(firstRule);
            var secondRuleFunc = ruleEngine.CompileRule<Person>(secondRule);
            var thirdRuleFunc = ruleEngine.CompileRule<Person>(thirdRule);
            var result = firstRuleFunc(person) && secondRuleFunc(person) && thirdRuleFunc(person);

            Assert.That(result,Is.True);
        }

        [Test]
        public void When_axa_then_calculate_buildings_cover_level()
        {
            var ruleLoader = new RuleLoader();

            var firstRule = ruleLoader.Load(9);
            var buildingsCover = new BuildingsCoverType();
            var ruleEngine = new RuleEngine();
            var firstRuleFunc = ruleEngine.CompileRule<BuildingsCoverType>(firstRule);
            var result = firstRuleFunc(buildingsCover);
            Assert.That(result, Is.True);
        }

    }

    public class BuildingsCoverType
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
