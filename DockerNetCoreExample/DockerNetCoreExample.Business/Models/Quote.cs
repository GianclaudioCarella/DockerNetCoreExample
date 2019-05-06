using System;
using System.Collections.Generic;
using System.Text;

namespace DockerNetCoreExample.Business.Models
{
    public class Quote
    {
        private string _sentence;

        public string Sentence
        {
            get => _sentence;
            set => _sentence = value.ToString();
        }

        private string _author;

        public string Author
        {
            get => _author;
            set => _author = value.ToString();
        }
    }
}
