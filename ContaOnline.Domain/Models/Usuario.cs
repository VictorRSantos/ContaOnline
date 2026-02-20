
namespace ContaOnline.Domain.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public List<string> Validar()
        {
            var list = new List<string>();

            if (string.IsNullOrWhiteSpace(Nome))
            {
                list.Add("O nome é obrigatório.");
            }
            else if (Nome.Length < 3)
            {
                list.Add("O nome deve ter pelo menos 3 caracteres.");
            }
            else if (string.IsNullOrWhiteSpace(Senha))
            {
                list.Add("A senha é obrigatória.");
            }

            return list;
        }


    }
}
