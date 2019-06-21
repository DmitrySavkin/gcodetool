
//Do not edit, this file is generated automatically !



// Dialog for  "SpiralCone Unfolding"
// (C) BASIC d.o.o., May 2018

PL_Razvoj : dialog {
  label = "SpiralCone Unfolding   (C) BASIC d.o.o. 2018";

     : row { 
     : column { 
  : boxed_column   { label="Spiral Data";
   : row {
     : column { 
     : button    { label = "Draw and unfold";   key = "DEMOmodel"; }
     : edit_box  { label = "Spiral  Gap:";    key = "Hrotor";  edit_width = 5; }
     : edit_box  { label = "Inlet  Radius:";  key = "Rinlet";  edit_width = 5; }
     : edit_box  { label = "Spiral Angle:";   key = "Aspiral"; edit_width = 5; }
     : button    { label = "CSV read and unfold";      key = "CSVfile"; }
     }
     : column {   
        : radio_row { 
           : radio_button { label = "Spiral (R)";     key="IsSpiral";     value = "1";}
           : radio_button { label = "Elbow (R+r)";    key="IsPipe";     value = "0";}
        }
     : edit_box  { label = "Spiral Radius:";  key = "Rrotor";  edit_width = 5;  }
     : edit_box  { label = "Final  Radius:";  key = "Rfinal";  edit_width = 5;  }
     : edit_box  { label = "Spiral Cones:";   key = "Nspiral"; edit_width = 5;  }
     : edit_box  {           key = "CSVpath";  }
     }
   }
}

: boxed_column   { label="Unfolding Settings";   
   : row {
  //   : edit_box { label = "Cone Segments";     key = "Nsegmentov";  edit_width = 3; fixed_width=true; width=8;}
  //   : edit_box { label = "Text Height";       key = "TxtSize";     edit_width = 3; fixed_width=true; width=8;}
     : column {
     : edit_box  { label = "Number of Segments"; key = "Nsegmentov";  edit_width = 3; }
     : edit_box  { label = "Text Height";        key = "TxtSize";     edit_width = 3; }
      }
     : column {  
        : toggle { label = "Angle Labels";       key="IzpisKotov";    value = "1";}
        : toggle { label = "Diagonals";          key="Diagonale";     value = "0";}
     }
   }
}

: boxed_column   { label="Manual Unfolding";
   : row {
     : button    {label = "Unfold";              key = "Unfold"; }
     : button    {label = "Erase Unfolding";     key = "EraseUnfolding"; width = 10; fixed_width = true;}
     : button    {label = "Erase Contours";      key = "EraseContours";  width = 10; fixed_width = true;}
   }
}

: boxed_column   { label="Views";   
   : row {
     : button    {label = "Plan";            key = "Pogled_2D"; }
     : button    {label = "3D";              key = "Pogled_3D";   }
     : button    {label = "Help";            key = "xHelp";  }
     : button    {label = "Uninstall";       key = "Uninstall";  }
     : button    {label = "Close/Cancel"; is_cancel = true; key = "Prekini";   }
   }
}
}
     : column {   
     : row { height = 2;   fixed_height = true;   
     : spacer { height = 2;   width = 20; color = 0;   } 
     : image { key = "Sld0";   height = 3;   width = 20; color = 0; fixed_height = true;  is_enabled = false;   is_tab_stop = false; } 
}
     : row { height = 1;   fixed_height = true;   
     : spacer {  height = 1;   width = 30; color = 0;   } 
     : text {  label= "CAD|CAM    www.basic.si";  height = 1;   width = 20; fixed_height = true; color = 0;    } 
}
     : image { key = "Sld1";   height = 20;  width = 50;  color = 0;  is_enabled = false;   is_tab_stop = false; } 
}
}

} // end of dialog okno1
