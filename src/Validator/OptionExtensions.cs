namespace Validator
{
    public static class OptionExtensions
    {
        public static Option<TElem> ToOption<TElem>(TElem elem) => Option<TElem>.Some(elem);
    }
}