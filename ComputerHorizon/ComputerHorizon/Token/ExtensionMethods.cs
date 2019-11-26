using System.Collections.Generic;
using System.Linq;
using ComputerHorizon.ModelsUtilisateur;

namespace ComputerHorizon.Token
{
    public class ExtensionMethods
    {
        public static IEnumerable<Utilisateur> WithoutPasswords(IEnumerable<Utilisateur> users)
        {
            //return users.Select(x => x.WithoutPassword());
            return null;
        }

        public static Utilisateur WithoutPassword(Utilisateur user) {
                user.Mdp = null;
                return user;
            }
        }
}