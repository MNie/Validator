namespace Validator.Tests
{
    using System.Collections.Generic;

    using Xunit;

    public class DogValidator : Validator<string>
    {
        private readonly string _name;
        private readonly string _breed;

        public DogValidator(string name, string breed)
        {
            _name = name;
            _breed = breed;
        }
        protected override IEnumerable<IRule<string>> GetRules()
        {
            return new[]
            {
                new Rule<string>(() => !string.IsNullOrEmpty(_name), "dogs name cannot be null"),
                new Rule<string>(() => !string.IsNullOrEmpty(_breed), "dogs breed cannot be null")
            };
        }
    }

    public class ValidatorTests
    {
        [Fact]
        public void WhenNameAndBreedPassThePrediction_ErrorArrayShouldBeEmpty()
        {
            const string DogsName = "bob";
            const string DogsBreed = "random";

            var validator = new DogValidator(DogsName, DogsBreed);
            var errors = validator.Validate();

            Assert.Empty(errors);
        }

        [Fact]
        public void WhenNameNotPassThePrediction_ErrorArrayContainInfoAboutIt()
        {
            const string DogsName = "";
            const string DogsBreed = "husky";

            var validator = new DogValidator(DogsName, DogsBreed);
            var errors = validator.Validate();

            Assert.Contains("dogs name cannot be null", errors);
        }
    }
}
