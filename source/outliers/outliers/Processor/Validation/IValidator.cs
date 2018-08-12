using outliers.DataModel;

namespace outliers.Processor.Validation
{
    public interface IValidator<T> where T : Data
    {
        // Validate a single data entry
        bool Validate(T data);
    }
}
