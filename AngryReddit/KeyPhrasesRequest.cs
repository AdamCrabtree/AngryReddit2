using Microsoft.ProjectOxford.Text.KeyPhrase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngryReddit
{
    class KeyPhrasesRequest
    {
        public async Task<List<String>> GetAngryTopics(List<String> angryTitles)
        {
            var apiKey = "bbc6ba589b8f47c9812914225fbc6ce0";
            List<String> angryTopics = new List<String>();
            foreach (var Title in angryTitles)
            {
                var document = new KeyPhraseDocument()
                {
                    Id = "2342342342",
                    Text = Title,
                    Language = "en"
                };
                var client = new KeyPhraseClient(apiKey);
                var request = new KeyPhraseRequest();
                request.Documents.Add(document);
                var response = await client.GetKeyPhrasesAsync(request);
                foreach (var doc in response.Documents)
                {
                    foreach (var keyPhrase in doc.KeyPhrases)
                    {
                        angryTopics.Add(keyPhrase);
                    }
                }
            }
            return angryTopics;
        }
    }
}
