#!/usr/bin/env groovy
    node {

      stage('Initialise') {
        /* Checkout the scripts */
        checkout scm: [
                $class: 'GitSCM',
                userRemoteConfigs: [
                        [
                                url: "https://github.com/DASANI-SCSJ4383/UTMDTE_WEB.git",
                        ]
                ],
                branches: [[name: "master"]]
        ], poll: false
      }

      stage('Complete any setup steps') {
		echo "Complete set-up steps"
      }

      stage('Execute Performance Tests') {
        dir("${WORKSPACE}/scripts") {
			bat 'D:/Afiq/Subject/SoftwareConstruction/apache-jmeter-5.5/bin/jmeter.bat -n -t test.jmx -l report.jtl'
        }
      }

      stage('Analyse Results') {
		echo "Analyse results"
      }
    }
