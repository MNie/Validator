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
        public void Test1()
        {
            var dogsName = "bob";
            var dogsBreed = "random";

            var validator = new DogValidator(dogsName, dogsBreed);
            var errors = validator.Validate();

            Assert.Empty(errors);
        }

        [Fact]
        public void Test2()
        {
            var dogsName = "bob";
            var dogsBreed = "husky";

            var validator = new DogValidator(dogsName, dogsBreed);
            var errors = validator.Validate();

            Assert.Empty(errors);
        }

        [Fact]
        public void Test3()
        {
            var dogsName = "";
            var dogsBreed = "husky";

            var validator = new DogValidator(dogsName, dogsBreed);
            var errors = validator.Validate();

            Assert.Contains("dogs name cannot be null", errors);
        }
    }
}
