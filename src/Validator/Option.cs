namespace Validator
{
    using System;

    public struct Option<T>
    {
        private readonly T some;

        private Option(T some)
        {
            this.IsSome = some != null;
            this.some = some;
        }

        public bool IsNone => !IsSome;

        public bool IsSome { get; }

        public static Option<T> Some(T value) => new Option<T>(value);
        public static Option<T> None() => new Option<T>();

        public T Value
        {
            get
            {
                if (this.IsNone)
                {
                    throw new InvalidOperationException("Cannot access Some of None");
                }

                return this.some;
            }
        }
    }
}