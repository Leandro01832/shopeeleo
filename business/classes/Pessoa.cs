using System.Collections.Generic;

namespace business.classes
{
    public class Pessoa : BaseModel
    {
        public string Email { get; set; }
        public virtual List<Loja> Lojas { get; set; }
    }
}
