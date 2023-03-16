<?
    $servername = "192.168.52.128";
    $username = "sa";
    $password = "1234";

    try {
        $conn = new PDO("mysql:host=$servername;dbname=CarDealership", $username, $password);
        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        echo "Connected successfully";
    } catch(PDOException $e) {
        echo "Connection failed: " . $e->getMessage();
    }
?>