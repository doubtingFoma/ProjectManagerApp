var gulp = require('gulp'),
    sass = require('gulp-sass'),
    browserSync = require('browser-sync');

gulp.task('watch', ['browserSync'], function () {
    gulp.watch('ProjectMangerAppReviso/Views/**.cshtml', browserSync.reload);
    gulp.watch('ProjectMangerAppReviso/Scripts/*.js', browserSync.reload);

    gulp.watch('ProjectMangerAppReviso/Content/scss/**/*.scss', ['sass']);

});


gulp.task('browserSync', function () {
    browserSync.init({
        server: {
            baseDir: 'app'
        }
    });
});



gulp.task('sass', function () {
    return gulp.src('ProjectMangerAppReviso/Content/scss/main.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('ProjectMangerAppReviso/Content/css'))
        .pipe(browserSync.stream());
});

gulp.task('default', ['sass', 'watch']);