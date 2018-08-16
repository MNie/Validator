namespace Validator
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Validator<TError>
    {
        private readonly IEnumerable<IRule<TError>> _rules;

        protected abstract IEnumerable<IRule<TError>> GetRules();

        public IEnumerable<TError> Validate() => this._rules.Apply().Select(x => x.Value);

        protected Validator() =>
            this._rules = this.GetRules();
    }
}