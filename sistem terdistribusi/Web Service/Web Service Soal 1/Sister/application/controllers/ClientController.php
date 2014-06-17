<?php
    class ClientController extends CI_Controller
    {
        function index()
        {
            $data['result'] = "";
            if(isset($_POST['formulir']))
            {
                $this->load->library("Nusoap_Library");
                $this->nusoap_client = new nusoap_client('http://localhost/Sister/ServerController?wsdl', true);
                $err = $this->nusoap_client->getError(); 
                if ($err) 
                {
                    $data['result'] = $err;

                }
                else
                {   
                    $input = array($_POST['input']);
                    $result = $this->nusoap_client->call('hash.get_'.$_POST['method'], $input);
                    if ($this->nusoap_client->fault) $data['result'] = $result;
                    else
                    {
                        $err = $this->nusoap_client->getError();
                        if ($err) $data['result'] = $err;
                        else $data['result'] = $result;
                    }
                }
            }
            $this->load->view('view', $data);
        }
    }
?>
