pipeline {
  agent {
    docker {
      image 'xunit'
    }

  }
  stages {
    stage('Test') {
      agent {
        docker {
          image 'xunit'
        }

      }
      steps {
        dotnetBuild()
        dotnetTest()
      }
    }

  }
}