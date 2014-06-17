<?php
    class ServerController extends CI_Controller
    {
        function ServerController()
        {
          parent::__construct();
          $this->load->library("Nusoap_Library"); // load nusoap toolkit library in controller
          $this->nusoap_server = new soap_server(); // create soap server object
          $this->nusoap_server->configureWSDL('sister_2014', 'urn:sister_2014'); // wsdl configuration
        
          //Methods Registration
          $this->nusoap_server->register('hash.get_md5',                 // method name
                            array('name' => 'xsd:string'),        // input parameters
                            array('return' => 'xsd:string'),      // output parameters
                            'urn:sister_2014',                      // namespace
                            'urn:sister_2014#md5',                // soapaction
                            'rpc',                                // style
                            'encoded',                            // use
                            'md5'            // documentation
                            );
          
          $this->nusoap_server->register('hash.get_sha1',                 // method name
                            array('name' => 'xsd:string'),        // input parameters
                            array('return' => 'xsd:string'),      // output parameters
                            'urn:sister_2014',                      // namespace
                            'urn:sister_2014#sha1',                // soapaction
                            'rpc',                                // style
                            'encoded',                            // use
                            'sha1'            // documentation
                            );
          
          $this->nusoap_server->register('hash.get_sha224',                 // method name
                            array('name' => 'xsd:string'),        // input parameters
                            array('return' => 'xsd:string'),      // output parameters
                            'urn:sister_2014',                      // namespace
                            'urn:sister_2014#sha224',                // soapaction
                            'rpc',                                // style
                            'encoded',                            // use
                            'sha224'            // documentation
                            );
        }
        
        function index()
        {
            //Load Model and Methods
            $this->load->model('hash');
            $this->nusoap_server->service(file_get_contents("php://input"));
        }      
    }
?>
