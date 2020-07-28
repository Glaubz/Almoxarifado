using System;

namespace Atividade_VI.Entities
{
    public class StockException : Exception
    {
        public StockException(string msg) : base(msg){
        }

    }
}