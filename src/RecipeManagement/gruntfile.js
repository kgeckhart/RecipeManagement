/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');

    grunt.initConfig({
        uglify: {
            options: {
                mangle: false
            },
            my_target: {
                files: { 'wwwroot/app.js': ['Scripts/app.js', 'Scripts/**/*.js'] }
            }
        },

        watch: {
            scripts: {
                files: ['Scripts/**/*.js'],
                tasks: ['uglify']
            }
        }
    });

    grunt.registerTask('default', ['uglify', 'watch']);
};

//module.exports = function (grunt) {
//    grunt.loadNpmTasks('grunt-contrib-uglify');
//    grunt.loadNpmTasks('grunt-contrib-watch');
//    grunt.loadNpmTasks('grunt-ng-annotate');

//    grunt.initConfig({
//        ngAnnotate: {
//            app: {
//                files: [
//                    {
//                        expand: true,
//                        cwd: 'Scripts',
//                        src: '**/*.js',
//                        dest: 'annotated/',   // Destination path prefix
//                        ext: '.js', // Dest filepaths will have this extension.
//                        extDot: 'last',       // Extensions in filenames begin after the last dot
//                    },
//                ],
//            }
//        },
        
//        uglify: {
//            options: {
//                report: 'min',
//                mangle: false
//            },
//            my_target: {
//                files: { 'wwwroot/app.js': ['annotated/**/*.js'] }
//            }
//        },

//        watch: {
//            scripts: {
//                files: ['Scripts/**/*.js'],
//                tasks: ['ngAnnotate', 'uglify']
//            }
//        }
//    });
//    grunt.registerTask('Watch-AnnotateAndUglify', ['ngAnnotate', 'uglify', 'watch']);
//};