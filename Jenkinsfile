pipeline {
  agent any
  stages {
    stage ('Code pull'){
        steps{
              checkout scm
        }
    }
    stage('Build docker') {
		agent {
			dockerfile true
		}
		steps {
			sh 'hostname'
			sh 'wget http://localhost:6969/'
      }
    }
  }
}
