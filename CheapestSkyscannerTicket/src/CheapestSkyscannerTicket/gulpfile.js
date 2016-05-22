/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');

var paths = { webroot: "./wwwroot/" };

var itemsToCopy = {
    './node_modules/angular/angular*.js': paths.webroot + 'lib/angular',
    './node_modules/angular-messages/angular-messages.js': paths.webroot + 'lib/angular',
    './node_modules/angucomplete-alt/angucomplete-alt.js': paths.webroot + 'lib/angular',
    './node_modules/angucomplete-alt/angucomplete-alt.css': paths.webroot + 'lib/angular',

    './node_modules/bootstrap/dist/css/bootstrap.css': paths.webroot + 'lib/bootstrap',
    './node_modules/bootstrap/dist/js/bootstrap.js': paths.webroot + 'lib/bootstrap',

    './node_modules/jquery/dist/jquery.js': paths.webroot + 'lib/jquery',

    './node_modules/jquery-ui-1-11-4/jquery-ui.js': paths.webroot + 'lib/jquery-ui',
    './node_modules/jquery-ui-1-11-4/jquery-ui.css': paths.webroot + 'lib/jquery-ui',
};

gulp.task('copy', function () {
    for (var src in itemsToCopy) {
        if (!itemsToCopy.hasOwnProperty(src)) continue;
        gulp.src(src).pipe(gulp.dest(itemsToCopy[src]));
    }
});