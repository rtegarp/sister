<?php
    class hash extends CI_Model
    {
        function get_md5($input)
        {
            return hash('md5', $input);
        }
        
        function get_sha1($input)
        {
            return hash('sha1', $input);
        }
        
        function get_sha224($input)
        {
            return hash('sha224', $input);
        }
    }
?>
