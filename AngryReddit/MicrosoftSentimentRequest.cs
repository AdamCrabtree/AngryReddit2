using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryReddit
{
    class MicrosoftSentimentRequest
    {
        public async Task<float> AnalyzeString(String redditTitle)
        {
            var apiKey = "834d70278ac84264b39b0eac12c61f76";
            var document = new SentimentDocument()
            {
                Id = "sfafaewfa",
                Text = redditTitle,
                Language = "en"
            };
            var request = new SentimentRequest();
            request.Documents.Add(document);
            var client = new SentimentClient("834d70278ac84264b39b0eac12c61f76");
            var response = await client.GetSentimentAsync(request);
            foreach (var doc in response.Documents)
            {
                return doc.Score * 100;
            }
            return 0;
        }

    }
}
