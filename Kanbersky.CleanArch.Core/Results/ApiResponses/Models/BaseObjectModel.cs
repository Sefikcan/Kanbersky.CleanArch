namespace Kanbersky.CleanArch.Core.Results.ApiResponses.Models
{
    public class BaseObjectModel<T>
    {
        public T Result { get; set; }

        public BaseObjectModel(T result)
        {
            Result = result;
        }
    }
}
