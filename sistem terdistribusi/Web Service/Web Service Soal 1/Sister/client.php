<?php
    // Pull in the NuSOAP code
    require_once('lib/nusoap.php');
    // Create the client instance
    $client = new soapclient('http://localhost/Sister/server.php?wsdl', true);
    // Check for an error
//    $err = $client->getError();
//    if ($err) {
//        // Display the error
//        echo '<h2>Constructor error</h2><pre>' . $err . '</pre>';
//        // At this point, you know the call that follows will fail
//    }
//    // Call the SOAP method
    $result = $client->call('hello', array('name' => 'Scott'));
//    // Check for a fault
//    if ($client->fault) {
//        echo '<h2>Fault</h2><pre>';
//        print_r($result);
//        echo '</pre>';
//    } else {
//        // Check for errors
//        $err = $client->getError();
//        if ($err) {
//            // Display the error
//            echo '<h2>Error</h2><pre>' . $err . '</pre>';
//        } else {
//            // Display the result
//            echo '<h2>Result</h2><pre>';
            print_r($result);
//        echo '</pre>';
//        }
//    }
?>