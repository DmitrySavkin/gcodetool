using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceLib
{
    interface IPackages
    {
        Package GetPackage(); 
    }


    interface III
    {
        IPackages GetPackages();
    }
}
