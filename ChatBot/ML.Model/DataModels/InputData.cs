using Microsoft.ML.Data;

namespace ChatBot.ML.Model.DataModels
{
    public class InputData
    {
        [ColumnName(@"col0")]
        public string Col0 { get; set; }

        [ColumnName(@"col1")]
        public float Col1 { get; set; }

        //public InputData(string request, int requestCategory)
        //{
        //    Request = request;
        //    RequestCategory = requestCategory;
        //}

        //public override string ToString()
        //{
        //    return $"\t{Request}\n-\n{RequestCategory}";
        //}
    }
}
