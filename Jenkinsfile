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
			sh 'dotnet test'
      }
    }
  }
}
