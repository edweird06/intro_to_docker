Import-Module Pester

Describe 'GO DOCKER!!' {
    for ($i = 0; $i -lt 20; $i++) {
        it "$i : should be amazing and pass" {
            $true | should be $true
        }
    }
}