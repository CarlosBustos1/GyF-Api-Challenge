namespace GyF_Api_Challenge.Core.Dtos
{
    public class KeyValueDto<TId>
    {
        public KeyValueDto(TId key, string value)
        {
            Key = key;
            Value = value;
        }
    
        public TId Key { get; set; }

        public string Value { get; set; }
    }
}
