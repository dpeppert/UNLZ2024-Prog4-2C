﻿using LogisticaContainers.Managers.Entidades.Auditoria;

namespace LogisticaContainers.Managers.Entidades
{
    public class Container : Audit
    {

        public int IdContainer { get; set; }
        public string DescripcionContainer { get; set; }

        public bool EstaCargado { get; set; }


    }





}
