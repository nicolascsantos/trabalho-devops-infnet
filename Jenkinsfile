pipeline {
    agents any // Pode ser substituido por um container Docker com o SDK do .NET, se a infra permitir.

    stages {
        stage('Checkout') {
            steps {
                echo 'Baixando o código do repositório...'
                checkout scm
            }
        }
    }
}