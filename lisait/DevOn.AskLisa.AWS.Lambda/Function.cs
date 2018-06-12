using System;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DevOn.AskLisa.AWS.Lambda
{
    public class Function
    {
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var logger = context.Logger;

            switch (input.Request)
            {
                case LaunchRequest launchRequest: return HandleLaunch(launchRequest, logger);
                case IntentRequest intentRequest: return HandleIntent(intentRequest, logger);
            }

            throw new NotImplementedException("Unknown request type.");
        }
        private SkillResponse HandleLaunch(LaunchRequest launchRequest, ILambdaLogger logger)
        {
            logger.LogLine($"LaunchRequest made");

            var response = ResponseBuilder.Tell(new PlainTextOutputSpeech()
            {
                Text = "Welcome! I am Lisa, You can ask me anything about DevOps."
            });

            return response;
        }

        private SkillResponse HandleIntent(IntentRequest intentRequest, ILambdaLogger logger)
        {
            logger.LogLine($"IntentRequest {intentRequest.Intent.Name} made");

            // Do Web Scraping and get the Data from websites
            //var responseSpeech = "Hello world";
            var responseSpeech = WebScraping.GetAllCertifications(CategoryOfQuestion.Certification)[0].Description;

            if (intentRequest.Intent.Slots.TryGetValue("City", out var citySlot))
            {
                if (!string.IsNullOrEmpty(citySlot.Value))
                {
                    responseSpeech += $" from {citySlot.Value}";
                }
            }

            responseSpeech += "!";

            var response = ResponseBuilder.Tell(new PlainTextOutputSpeech()
            {
                Text = responseSpeech
            });

            return response;
        }
    }
}
