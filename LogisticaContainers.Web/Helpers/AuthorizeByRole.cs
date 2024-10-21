using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LogisticaContainers.Web.Helpers
{
    public class AuthorizeByRoleAttribute : Attribute, IAuthorizationFilter
    {
         
            private string[] _claimsRequeridas;

            public AuthorizeByRoleAttribute(params string[] claimsRequeridas)
            {

                this._claimsRequeridas = claimsRequeridas;
            }
            public void OnAuthorization(AuthorizationFilterContext context)
            {

                var user = context.HttpContext.User;


                //Confirmo que esté el usuario
                if (user == null)
                {
                    //Si el usuario no esta, lanzo un mensaje de sin autorizacion
                    context.Result = new UnauthorizedObjectResult(string.Empty);
                    return;

                }

                //Obtengo las claims del usuario
                var claims = user.Claims.ToList();

                //Confirmo que haya al menos una claim
                if (!claims.Any())
                {

                    //Si no tengo claims de usuario, lanzo un mensaje de sin autorizacion
                    context.Result = new UnauthorizedObjectResult(string.Empty);
                    return;
                }


                //Filtro las claims correspondiente a los roles
                claims = claims.Where(x => x.Type.ToUpperInvariant().Contains("UNLZRole")).ToList();



                //por defecto no existe
                bool existe = false;

                //Recorro las claims
                foreach (var claim in claims)
                {
                    //Si no existe
                    if (!existe)  //Consulto que la claims del usuario coincida con alguna de las claims requeridas
                        existe = _claimsRequeridas.Any(X => X.ToUpperInvariant() == claim.Value.ToUpperInvariant());

                }

                //Si existe
                if (existe)
                    return; //dejo pasar
                else
                {

                    //Si finalmente no existe, lanzo un mensaje de sin autorizacion
                    context.Result = new UnauthorizedObjectResult(string.Empty);
                    return;
                }



            }


     }
}
