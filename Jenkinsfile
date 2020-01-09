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
			sh 'dotnet --version'
			sh 'wget http://localhost/'
			sh 'wget http://localhost:5000/'
			sh 'wget http://localhost:5001/'
      }
    }
  }
}
