using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ProjectOxford.Text.Sentiment;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AngryReddit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            List<string> angryTitles = new List<String>();
            angryTitles = analyzeSubreddit("/r/politics").Result;
            List<String> angryTopics = new List<String>();
            Console.Write("just seeing how github works");
            angryTopics = analyzeTitles(angryTitles).Result;
            
        }
        async Task<List<string>> analyzeSubreddit(String subreddit)
        {
            List<String> angryTitles = new List<String>();
            RedditRequest myReddit = new AngryReddit.RedditRequest();
            angryTitles = await myReddit.AnalyzeTopPosts(subreddit);
            return angryTitles;
        }
        async Task<List<string>> analyzeTitles(List<string> Titles)
        {
            List<String> angryTopics = new List<String>();
            KeyPhrasesRequest keyPhraseRequest = new AngryReddit.KeyPhrasesRequest();
            angryTopics = await keyPhraseRequest.GetAngryTopics(Titles);
            return angryTopics;
        }
    }
}
