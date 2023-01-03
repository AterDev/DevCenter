import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { JobType } from 'src/app/share/models/enum/job-type.model';
import { SSHOption } from 'src/app/share/models/tools/sshoption.model';
import { ToolsService } from 'src/app/share/services/tools.service';

@Component({
  selector: 'app-generate-ci',
  templateUrl: './generate-ci.component.html',
  styleUrls: ['./generate-ci.component.css']
})
export class GenerateCIComponent implements OnInit {
  JobType = JobType;
  formGroup!: FormGroup;
  data = {} as SSHOption;
  ymlContent = '';
  constructor(
    private service: ToolsService,
    public snb: MatSnackBar
  ) {

  }
  get jobName() { return this.formGroup.get('jobName'); }
  get type() { return this.formGroup.get('type'); }
  get sshHost() { return this.formGroup.get('sshHost'); }
  get projectPath() { return this.formGroup.get('projectPath'); }
  get publishPath() { return this.formGroup.get('publishPath'); }
  get runPath() { return this.formGroup.get('runPath'); }
  get serviceName() { return this.formGroup.get('serviceName'); }

  ngOnInit(): void {
    this.initForm();
  }

  initForm(): void {
    this.formGroup = new FormGroup({
      jobName: new FormControl(null, [Validators.required]),
      type: new FormControl(JobType.Dotnet),
      sshHost: new FormControl(null, [Validators.required]),
      projectPath: new FormControl(null, []),
      publishPath: new FormControl(null, [Validators.required]),
      runPath: new FormControl(null, [Validators.required]),
      serviceName: new FormControl('', []),
    });
  }

  getValidatorMessage(type: string): string {
    switch (type) {
      case 'jobName':
        return this.jobName?.errors?.['required'] ? 'jobName必填' :
          this.jobName?.errors?.['minlength'] ? 'Name长度最少位' :
            this.jobName?.errors?.['maxlength'] ? 'Name长度最多30位' : '';
      case 'sshHost':
        return this.sshHost?.errors?.['required'] ? 'sshHost必填' :
          this.sshHost?.errors?.['minlength'] ? 'sshHost长度最少位' :
            this.sshHost?.errors?.['maxlength'] ? 'sshHost长度最多30位' : '';
      case 'projectPath':
        return this.projectPath?.errors?.['required'] ? 'projectPath必填' :
          this.projectPath?.errors?.['minlength'] ? 'projectPath长度最少位' :
            this.projectPath?.errors?.['maxlength'] ? 'projectPath长度最多位' : '';
      case 'publishPath':
        return this.publishPath?.errors?.['required'] ? 'publishPath必填' : '';
      case 'runPath':
        return this.publishPath?.errors?.['required'] ? 'runPath必填' : '';
      case 'serviceName':
        return this.publishPath?.errors?.['required'] ? 'serviceName必填' : '';
      default:
        return '';
    }
  }

  generate(): void {
    if (this.formGroup.valid) {
      this.data = this.formGroup.value as SSHOption;
      console.log(this.data);

      this.service.generateCIYml(this.data)
        .subscribe(res => {
          this.ymlContent = res;
          // this.dialogRef.close(res);
          // this.router.navigate(['../index'], { relativeTo: this.route });
        });
    }
  }
}
