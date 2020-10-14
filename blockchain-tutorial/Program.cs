using System;
using System.Security.Cryptography;
using System.Text;
using static System.Console;

namespace blockchain_tutorial
{
    class Program
    {

        class Block
        {

            //PROPIEDADES DE LA CLASE
            public byte[] hash { get; set; }
            
            public string data { get; set; }
            public int nonce { get; set; }


            /*public Block(string hash, int nonce)
            {
                this.hash = hash;
                this.nonce = nonce;
            }*/

            public byte[] generate_hash()
            {
                string complete = Convert.ToString(this.nonce) + this.data; 
                byte[] c_byte = Encoding.ASCII.GetBytes(complete),conver;
                SHA256 sha = SHA256.Create();
                conver = sha.ComputeHash(c_byte);
                return conver;
            }


        }


        static void Main(string[] args)
        {
 
            Block ob1 = new Block();

            ob1.data = "sebasTOrobert100";
            ob1.nonce = 0;
            ob1.hash = ob1.generate_hash();

            for(int i = 0; i < ob1.hash.Length; i++)
            {
                Write($"{ob1.hash[i]:X2}");
               
            }
            //

        }


    
    }

}
