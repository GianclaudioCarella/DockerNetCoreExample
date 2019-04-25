using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNetCoreExample.Business.Model
{
    public class Quote
    {
        public Quote(string sentence, string author)
        {
            Sentence = sentence;
            Author = author;
        }

        private string _sentence;
        public string Sentence
        {
            get => _sentence;
            set => _sentence.ToString();
        }

        private string _author;
        public string Author
        {
            get => _author;
            set => _author.ToString();
        }
    }
}
