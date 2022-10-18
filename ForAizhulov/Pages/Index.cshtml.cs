using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ForAizhulov.Patterns;

namespace ForAizhulov.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Word { get; set; }
        public string Key { get; set; }
        public bool Visiner { get; set; }
        public bool Atbash { get; set; }
        public bool ADFGX { get; set; }
        public bool XOR { get; set; }
        public bool Caesar { get; set; }

        public string encryptedWord;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public void OnPost(string word, string key, bool Visiner, bool Atbash, bool ADFGX, bool XOR, bool Caesar)
        {
            this.Word = word;
            this.Key = key;
            this.Visiner = Visiner;
            this.Atbash = Atbash;
            this.ADFGX = ADFGX;
            this.XOR = XOR;
            this.Caesar = Caesar;

            CipherRoot cipherRoot = new CipherRoot();

            if (Visiner)
            {
                LeafCipher leafCipher = new LeafCipher();
                leafCipher.AddCipher(new VisinerCipher());
                cipherRoot.AddComponentCipher(leafCipher);
                Console.WriteLine("Hello");
            }

            if (Atbash)
            {
                LeafCipher leafCipher = new LeafCipher();
                leafCipher.AddCipher(new AtbashCipher());
                cipherRoot.AddComponentCipher(leafCipher);
            }

            if (ADFGX)
            {
                LeafCipher leafCipher = new LeafCipher();
                leafCipher.AddCipher(new ADFGXCipher());
                cipherRoot.AddComponentCipher(leafCipher);
            }

            if (XOR)
            {
                LeafCipher leafCipher = new LeafCipher();
                leafCipher.AddCipher(new XORCipher());
                cipherRoot.AddComponentCipher(leafCipher);
            }
            encryptedWord = Encrypt(cipherRoot);

            Serialize_PIVO_tandem serialize_PIVO_Tandem = new Serialize_PIVO_tandem();
            serialize_PIVO_Tandem.EncryptedWord = encryptedWord;
            Adapter_kotoryi_Singleton adapter_Kotoryi_Singleton = Adapter_kotoryi_Singleton.GetInstance2();
            adapter_Kotoryi_Singleton.JsonVozvrat(serialize_PIVO_Tandem);
            adapter_Kotoryi_Singleton.XMLReturn(serialize_PIVO_Tandem);

        }
        private IComponent SetCiphers()
        {
            CipherRoot cipherRoot = new CipherRoot();

            if (Visiner)
            {
                LeafCipher leafCipher = new LeafCipher();
                leafCipher.AddCipher(new VisinerCipher());
                cipherRoot.AddComponentCipher(leafCipher);
            }

            if (Atbash)
            {
                LeafCipher leafCipher = new LeafCipher();
                leafCipher.AddCipher(new AtbashCipher());
                cipherRoot.AddComponentCipher(leafCipher);
            }

            if(ADFGX)
            {
                LeafCipher leafCipher = new LeafCipher();
                leafCipher.AddCipher(new ADFGXCipher());
                cipherRoot.AddComponentCipher(leafCipher);
            }

            if (XOR)
            {
                LeafCipher leafCipher = new LeafCipher();
                leafCipher.AddCipher(new XORCipher());
                cipherRoot.AddComponentCipher(leafCipher);
            }

            return cipherRoot;
        }

        private string Encrypt(IComponent cipherRoot)
        {
            string word;
            try
            {
                IIterator it = cipherRoot.CreateIterator();
                word = cipherRoot.GetElement().EncryptWord(Word, Key);

                while (!it.isDone())
                {
                    word = cipherRoot.GetNextElement().EncryptWord(word, Key);

                }
            }
            catch
            {
                word = Word;
            }

            return word;
        } 
    }
}