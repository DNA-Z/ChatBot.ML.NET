using Microsoft.ML.Data;

namespace ChatBot.ML.Model.DataModels
{
    public class OutputData
    {
        [ColumnName("PredictedLabel")]
        public float PredictionLabel { get; set; }

        //public float[] Score { get; set; }
    }
}
