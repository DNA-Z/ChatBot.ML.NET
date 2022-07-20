using ChatBot.ML.Model.DataModels;
using Microsoft.ML;

namespace ChatBot.ML.Model
{
    public class UseML
    {   
        public int PredicateML(string response)
        {
            var newSample = new InputData
            {
                Col0 = response
            };

            MLContext mlContext = new MLContext();

            //Define DataViewSchema for data preparation pipeline and trained model
            DataViewSchema modelSchema;

            // Load trained model
            ITransformer trainedModel = mlContext.Model.Load("ChatbotMLModel.zip", out modelSchema);
            //"MLModel1.zip"

            var predictor = new Predictor();
            var prediction = predictor.Predict(newSample);

            int resPredict = Convert.ToInt32(prediction.PredictionLabel);

            return resPredict;
        }
    }
}
