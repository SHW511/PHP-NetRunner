<?php
// router.php
if (php_sapi_name() == 'cli-server') {
    /* route static assets and return false */
	if (preg_match('/\.(?:png|jpg|jpeg|gif|css|js)$/', $_SERVER["REQUEST_URI"])) {
			return false;    // serve the requested resource as-is.
		}
}
/* go on with normal index.php operations */
?>
<h1>Hello World!</h1>

<?php

//print_r($_ENV);

//print_r(ini_get_all());

$link = mysqli_connect("127.0.0.1", "root", "Erazer511", "sys");
if($link === false){
	die("ERROR: Could not connect. " . mysqli_connect_error());
}

phpinfo();	

?>