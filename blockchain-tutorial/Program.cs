using System;
using System.Collections.Generic;
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


 
            public byte[] generate_hash()
            {
                string complete = Convert.ToString(this.nonce) + this.data; 
                byte[] c_byte = Encoding.ASCII.GetBytes(complete),conver;
                SHA256 sha = SHA256.Create();
                conver = sha.ComputeHash(c_byte);
                return conver;
            }

            public int generate_genesis()
            {
                this.nonce = 0;
                this.data = "SatoshiTOBob100";
                this.hash = generate_hash();
                return 0;
            }


        }

        class Blockchain
        {
            
            public byte[] prev_hash { get; set; }


        }


        static void Main(string[] args)
        {

            //Blockchain blockchain = new Blockchain();
            Block ob1 = new Block();
            List<Block> blockchain = new List<Block>();
            
            ob1.data = "sebasTOrobert100";
            ob1.nonce = 0;
            ob1.hash = ob1.generate_hash();
            blockchain.Add(ob1);

            PrintBytes(ob1.hash); 

        }


        static void PrintBytes(byte[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Write($"{array[i]:X2}");

            }
        }
    }



}
