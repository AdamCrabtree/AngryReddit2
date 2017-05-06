using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;

namespace AngryReddit
{
    class RedditRequest
    {
        public async Task<List<string>> AnalyzeTopPosts(String subredditString)
        {
            var reddit = new Reddit();
            List<String> angryTitles = new List<String>();
            var subreddit = reddit.GetSubreddit(subredditString);
            foreach (var post in subreddit.Hot.Take(25))
            {
                MicrosoftSentimentRequest sentimentRequest = new AngryReddit.MicrosoftSentimentRequest();
                float sentiment = await sentimentRequest.AnalyzeString(post.Title);
                if (sentiment < 20)
                {
                    angryTitles.Add(post.Title);
                }
            }
            return angryTitles;
        }

    }
}
