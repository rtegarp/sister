<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
            <title>Sister 2014</title>
        </head>
        <body>
            <table  style="alignment-adjust:central">
                <form name="formulir" action="ClientController" method="post">
                <tr>
                 <td>Method </td>
                 <td>
                     <input type="text" name="method"
                     <?php
                            if(isset($_POST['formulir']))
                            {
                                echo "value="."'".$_POST['method']."'";
                            }
                        ?>       
                     />
                 </td>
                </tr>
                <tr>
                 <td>Input </td>
                 <td>
                     <input type="text" name="input"
                    <?php
                        if(isset($_POST['formulir']))
                        {
                            echo "value="."'".$_POST['input']."'";
                        }
                    ?>       
                     />
                 </td>
                </tr>        
                <tr>
                 <td>
                     Result
                 </td>
                    <td>
                        <?php
                            if(isset($_POST['formulir']))
                            {
                                echo $result;
                            }
                        ?>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><input type="submit" value="Go" name="formulir" style="width:200px"/></td>
                </tr>    
            </table>
        </form>
        </body>
    </html>