using System;
using System.Collections.Generic;
using System.Text;


public class Casting
{

    public static void castingemp()
    {
        var man1 = new CastingManager();
        var emp1 = new CastingEmployee();

        //Hard Casting. If this fails it will throw an Exception!!
        var man2 = (CastingManager)emp1;

        //
        //Examines the object type and makes sure you can cast 
        //returns a bool
        if (emp1 is CastingManager)
        {

        }

        //Tries to Cast but if it fails then it reurns a null value
        CastingManager man3 = (emp1 as CastingManager);
    }
}

public class CastingEmployee
{
    protected int employeeNumber;
    protected string fullName;

}

public class CastingManager : CastingEmployee
{


}

public class CastingFTEmployee : CastingEmployee
{


}

public class CastingPTEmployee : CastingEmployee
{


}