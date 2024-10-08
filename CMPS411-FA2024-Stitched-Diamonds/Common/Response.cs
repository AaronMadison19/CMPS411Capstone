using System.Collections.Generic;

namespace CMPS411_FA2024_Stitched_Diamonds.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public List<Error> Errors { get; set; } = new List<Error>();
        public bool HasErrors => Errors.Count > 0;

        public void AddError(string property, string message)
        {
            Errors.Add(new Error(property, message));
        }
    }
}
